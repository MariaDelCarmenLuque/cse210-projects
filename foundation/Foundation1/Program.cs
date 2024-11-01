using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
    
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Understanding the Book of Mormon", "Elder Johnson", 600);
        video1.AddComment(new Comment("Sister Brown", "This really helped me understand Nephi's role!"));
        video1.AddComment(new Comment("Elder Smith", "I love how you broke down the chapters."));
        video1.AddComment(new Comment("Mary", "Thank you for sharing your insights!"));

        Video video2 = new Video("Prayer and Personal Revelation", "Sister White", 450);
        video2.AddComment(new Comment("John", "This video strengthened my faith in prayer."));
        video2.AddComment(new Comment("Rachel", "I appreciate the tips on how to receive guidance."));
        video2.AddComment(new Comment("Mark", "This was a great reminder to seek help through prayer."));

        Video video3 = new Video("Faith and Action", "Brother Davis", 300);
        video3.AddComment(new Comment("Anna", "Such a motivating message, thank you!"));
        video3.AddComment(new Comment("Jacob", "I feel inspired to serve more in my community."));

        Video video4 = new Video("The Creation Story in Genesis", "Elder Thompson", 550);
        video4.AddComment(new Comment("Sarah", "This video beautifully explains the creation process. Thank you!"));
        video4.AddComment(new Comment("David", "I love the insights you shared about the creation days."));
        video4.AddComment(new Comment("Rachel", "Such a great reminder of God's power in creation."));

        Video video5 = new Video("Lessons from the Life of Moses", "Sister Wilson", 720);
        video5.AddComment(new Comment("Daniel", "Moses' story is so inspiring. Great analysis!"));
        video5.AddComment(new Comment("Emily", "I learned so much about leadership from this video."));
        video5.AddComment(new Comment("Mark", "Thank you for sharing these important lessons!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);
        videos.Add(video5);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
