using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.Json;

namespace TextRPG_sparta
{
    internal static class SaveLoadManager
    {
        private static readonly string SaveDirectory = "Saves";

        static SaveLoadManager()
        {
            // 저장 폴더가 없으면 생성
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
        }

        // 데이터를 JSON 형식으로 저장
        public static void Save<T>(T data, string fileName)
        {
            try
            {
                string filePath = Path.Combine(SaveDirectory, fileName + ".json");
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                Console.WriteLine($"데이터 저장 완료: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"저장 오류: {ex.Message}");
            }
        }

        // JSON 형식 데이터를 불러오기
        public static T? Load<T>(string fileName) where T : class
        {
            try
            {
                string filePath = Path.Combine(SaveDirectory, fileName + ".json");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"파일이 존재하지 않음: {filePath}");
                    return null;  // null 반환
                }

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"불러오기 오류: {ex.Message}");
                return null;
            }
        }

        // 파일 존재 여부 확인 함수 추가
        public static bool FileExists(string fileName)
        {
            string filePath = Path.Combine(SaveDirectory, fileName + ".json");
            return File.Exists(filePath);
        }
    }
}
