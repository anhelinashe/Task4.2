using System;
using System.Collections.Generic;

namespace socialnetwork;
    internal class Program
    {
        public class Profile
        {
            public string Name;
            public string ContactEmail;
            public string Handle;
            private List<Update> Updates;

            public Profile(string name, string contactEmail, string handle)
            {
                Name = name;
                ContactEmail = contactEmail;
                Handle = handle;
                Updates = new List<Update>();
            }

            public void CreateUpdate(string timestamp, string content)
            {
                Update update = new Update(timestamp, content);
                Updates.Add(update);
                Console.WriteLine("A new update has been posted.");
            }

            public void RemoveUpdate(string timestamp, string content)
            {
                Update updateToDelete = Updates.Find(u => u.Timestamp == timestamp && u.Content == content);
                if (updateToDelete != null)
                {
                    Updates.Remove(updateToDelete);
                    Console.WriteLine("Update has been removed.");
                }
                else
                {
                    Console.WriteLine("Update not found.");
                }
            }

            public void DisplayUpdates()
            {
                if (Updates.Count == 0)
                {
                    Console.WriteLine("No updates available.");
                    return;
                }
                for (int i = 0; i < Updates.Count; i++)
                {
                    Update update = Updates[i];
                    Console.WriteLine($"Update: {update.Timestamp} - {update.Content}. Likes: {update.LikeCount}. Comments: {update.Comments.Count}");
                }
            }

            public Update GetUpdate(int index)
            {
                if (index >= 0 && index < Updates.Count)
                {
                    return Updates[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid update index.");
                }
            }

            public int GetUpdateCount()
            {
                return Updates.Count;
            }
        }

        public class Update
        {
            public string Timestamp;
            public string Content;
            public int LikeCount;
            public List<string> Comments;

            public Update(string timestamp, string content)
            {
                Timestamp = timestamp;
                Content = content;
                LikeCount = 0;
                Comments = new List<string>();
            }

            public void AddLike()
            {
                LikeCount++;
            }

            public void AddComment(string comment)
            {
                Comments.Add(comment);
            }
        }

        static void LikeUpdate(Update update)
        {
            update.AddLike();
            Console.WriteLine("You've liked this update.");
        }

        static void CommentOnUpdate(Update update)
        {
            Console.WriteLine("Enter your comment:");
            string comment = Console.ReadLine();
            update.AddComment(comment);
            Console.WriteLine("Comment added.");
        }

        static void Main(string[] args)
        {
            Profile[] profiles = {
                new Profile("Shrek", "shrek@gmail.com", "@shrek"),
                new Profile("Fiona", "fiona@gmail.com", "@fiona"),
                new Profile("Donkey", "donkey@gmail.com", "@donkey"),
                new Profile("Gingerbread Man", "gingerbread.man@gmail.com", "@gingerbread.man")
            };

            profiles[0].CreateUpdate("05-06-2018", "Me and Donkey");
            profiles[0].CreateUpdate("07-08-2018", "Great");
            profiles[0].CreateUpdate("25-03-2020", "WOW!");
            profiles[1].CreateUpdate("01-01-2022", "Excellent");
            profiles[1].CreateUpdate("12-09-2023", "My family.Shrek love you.");
            profiles[2].CreateUpdate("08-02-2020", "Cutie.");
            profiles[2].CreateUpdate("29-07-2023", "Happy b-day to me!");
            profiles[2].CreateUpdate("03-02-2024", "Happy b-day my love.");
            profiles[2].CreateUpdate("16-08-2024", "My lovely dragon");
            profiles[3].CreateUpdate("18-08-2016", "First post");
            profiles[3].CreateUpdate("22-03-2020", "Hello world!");
            profiles[3].CreateUpdate("07-02-2021", "Update number three.");
            profiles[3].CreateUpdate("29-07-2024", "Successful");

            LikeUpdate(profiles[0].GetUpdate(0));
            LikeUpdate(profiles[0].GetUpdate(0));
            LikeUpdate(profiles[1].GetUpdate(1));
            LikeUpdate(profiles[1].GetUpdate(1));
            LikeUpdate(profiles[2].GetUpdate(0));
            LikeUpdate(profiles[2].GetUpdate(0));
            LikeUpdate(profiles[2].GetUpdate(0));
            LikeUpdate(profiles[2].GetUpdate(2));
            LikeUpdate(profiles[3].GetUpdate(0));
            LikeUpdate(profiles[3].GetUpdate(0));
            LikeUpdate(profiles[3].GetUpdate(1));
            LikeUpdate(profiles[3].GetUpdate(2));

            CommentOnUpdate(profiles[2].GetUpdate(1));
            CommentOnUpdate(profiles[2].GetUpdate(0));

            profiles[2].DisplayUpdates();
            for (int i = 0; i < profiles.Length; i++)
            {
                Profile profile = profiles[i];
                Console.WriteLine($"\nUpdates for {profile.Name} ({profile.Handle}):");
                profile.DisplayUpdates();
            }
        }
    }
}
