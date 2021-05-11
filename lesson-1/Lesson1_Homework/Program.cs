using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Lesson1_Homework
{
    class Program
    {
        private static readonly HttpClient _client = new HttpClient();

        static async Task Main(string[] args)
        {
            int startId = 4;
            int stopId = 13;
            for (int id = startId; id <= stopId; id++)
            {
                if (await GetPost(id))
                {
                    Console.WriteLine($"ID: {id} - OK");
                }
                else
                {
                    Console.WriteLine($"ID: {id} - Error");
                }
            }  
        }

        static async Task<bool> GetPost(int id)
        {
            var response = await _client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error while getting an http response id: {id}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<Post>(content);
            if (SaveInFile(post))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool SaveInFile(Post post)
        {
            string filePath = @"C:\Users\User\OneDrive\GB\6.WebApplication\Lesson1_Homework\result.txt";
            File.AppendAllText(filePath, post.UserId.ToString() + "\n");
            File.AppendAllText(filePath, post.Id.ToString() + "\n");
            File.AppendAllText(filePath, post.Title.ToString() + "\n");
            File.AppendAllText(filePath, post.Body.ToString() + "\n");
            File.AppendAllText(filePath, Environment.NewLine);

            return true;
        }

    }
    class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
