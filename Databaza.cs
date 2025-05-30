
using Microsoft.Data.Sqlite;
using System.Text.Json;
using System.IO;

public class Databaza
{
    private static readonly string cesta = Path.Combine(Directory.GetCurrentDirectory(), "vodicak.db");
    protected static string spojenie = $"Data Source={cesta}";

    public static SqliteConnection OtvorSpojenie()
    {
        var spojenieObj = new SqliteConnection(spojenie);
        spojenieObj.Open();
        return spojenieObj;
    }

    public static void InicializujAdatbazist()
    {
        if (File.Exists(cesta))
        {
            File.Delete(cesta);
            Console.WriteLine("Korábbi adatbázis törölve.");
        }

        using var conn = OtvorSpojenie();

        var fkCmd = conn.CreateCommand();
        fkCmd.CommandText = "PRAGMA foreign_keys = ON;";
        fkCmd.ExecuteNonQuery();

        var schemaSql = File.ReadAllText("schema.sql");
        var createCmd = conn.CreateCommand();
        createCmd.CommandText = schemaSql;
        createCmd.ExecuteNonQuery();

        Console.WriteLine("Adatbázis újralétrehozva a schema.sql alapján.");
    }

    public static void ImportFromJson(string questionsPath, string answersPath)
    {
        Console.WriteLine("Adatok betöltése JSON fájlokból...");

        using var conn = OtvorSpojenie();

        var fkCmd = conn.CreateCommand();
        fkCmd.CommandText = "PRAGMA foreign_keys = ON;";
        fkCmd.ExecuteNonQuery();

        var answersJson = File.ReadAllText(answersPath);
        var questionsJson = File.ReadAllText(questionsPath);

        var correctWrapper = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(answersJson);
        var correctAnswers = correctWrapper["correct_answers"];

        using var doc = JsonDocument.Parse(questionsJson);
        var questions = doc.RootElement;

        int i = 0;
        foreach (var q in questions.EnumerateArray())
        {
            string text = q.GetProperty("question").GetString() ?? "";
            string image = q.GetProperty("image").GetString() ?? "";
            var answers = q.GetProperty("answers").EnumerateArray().Select(a => a.GetString() ?? "").ToList();

            Console.WriteLine($"> Kérdés {i + 1}: {text}");

            var insertQuestionCmd = conn.CreateCommand();
            insertQuestionCmd.CommandText = "INSERT INTO Otazka (text) VALUES ($text);";
            insertQuestionCmd.Parameters.AddWithValue("$text", text);
            insertQuestionCmd.ExecuteNonQuery();

            var getIdCmd = conn.CreateCommand();
            getIdCmd.CommandText = "SELECT last_insert_rowid();";
            var result = getIdCmd.ExecuteScalar();
            if (result == null)
            {
                Console.WriteLine("  [HIBA] Nem sikerült lekérni a kérdés ID-t.");
                i++;
                continue;
            }
            var questionId = (long)result;

            if (!string.IsNullOrWhiteSpace(image))
            {
                Console.WriteLine("  → Kép: " + image);
                var insertImageCmd = conn.CreateCommand();
                insertImageCmd.CommandText = "INSERT INTO Obrazok (otazkaId, subor) VALUES ($id, $img);";
                insertImageCmd.Parameters.AddWithValue("$id", questionId);
                insertImageCmd.Parameters.AddWithValue("$img", image);
                insertImageCmd.ExecuteNonQuery();
            }

            if (answers.Count == 0)
            {
                Console.WriteLine("  [FIGYELMEZTETÉS] Nincsenek válaszok.");
                i++;
                continue;
            }

            if (i >= correctAnswers.Count)
            {
                Console.WriteLine("  [HIBA] Nincs megfelelő helyes válasz a sorszámhoz.");
                i++;
                continue;
            }

            for (int j = 0; j < answers.Count; j++)
            {
                bool isCorrect = correctAnswers[i].Trim().ToLower() == "abcd"[j].ToString();
                var insertAnswerCmd = conn.CreateCommand();
                insertAnswerCmd.CommandText = @"
                    INSERT INTO Odpoved (otazkaId, text, jeSpravna) 
                    VALUES ($id, $text, $correct);";
                insertAnswerCmd.Parameters.AddWithValue("$id", questionId);
                insertAnswerCmd.Parameters.AddWithValue("$text", answers[j]);
                insertAnswerCmd.Parameters.AddWithValue("$correct", isCorrect ? 1 : 0);
                insertAnswerCmd.ExecuteNonQuery();

                Console.WriteLine($"    - [{(isCorrect ? "HELYES" : "hibás")}] {answers[j]}");
            }

            Console.WriteLine("  [OK] Kérdés és válaszok rögzítve.");
            i++;
        }

        Console.WriteLine("✅ Importálás kész.");
    }
}
