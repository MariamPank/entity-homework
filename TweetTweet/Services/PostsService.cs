using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetTweet.Data;
using TweetTweet.Models;

namespace TweetTweet.Services
{
    internal class PostsService
    {
        DataContext _db = new DataContext();

        public void CreatePost()
        {
            Console.Write("Enter user id: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid user id!");
                return;
            }

            var user = _db.Users.Find(userId);

            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            Console.Write("Enter post title: ");
            string title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Post title is required!");
                return;
            }

            Console.Write("Enter post body: ");
            string body = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(body))
            {
                Console.WriteLine("Post body is required!");
                return;
            }

            Post post = new Post()
            {
                PostTitle = title,
                PostBody = body,
                UserId = userId
            };

            _db.Posts.Add(post);
            _db.SaveChanges();

            Console.WriteLine("Post created successfully.");
        }

        public void ShowAllPosts()
        {
            var posts = _db.Posts
                .Include(p => p.User)
                .ToList();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post Id: {post.Id}");
                Console.WriteLine($"Title: {post.PostTitle}");
                Console.WriteLine($"Body: {post.PostBody}");
                Console.WriteLine($"User: {post.User.Username}");
                Console.WriteLine("--------------------------");
            }
        }

        public void ShowPostsByUserId()
        {
            Console.Write("Enter user id: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid user id!");
                return;
            }

            var posts = _db.Posts
                .Where(p => p.UserId == userId)
                .ToList();

            if (!posts.Any())
            {
                Console.WriteLine("No posts found for this user.");
                return;
            }

            foreach (var post in posts)
            {
                Console.WriteLine($"Post Id: {post.Id}");
                Console.WriteLine($"Title: {post.PostTitle}");
                Console.WriteLine($"Body: {post.PostBody}");
                Console.WriteLine("--------------------------");
            }
        }

        public void DeletePost()
        {
            Console.Write("Enter post id: ");
            if (!int.TryParse(Console.ReadLine(), out int postId))
            {
                Console.WriteLine("Invalid post id!");
                return;
            }

            var post = _db.Posts.Find(postId);

            if (post == null)
            {
                Console.WriteLine("Post not found!");
                return;
            }

            _db.Posts.Remove(post);
            _db.SaveChanges();

            Console.WriteLine("Post deleted successfully.");
        }

        public void UpdatePost()
        {
            Console.Write("Enter post id: ");
            if (!int.TryParse(Console.ReadLine(), out int postId))
            {
                Console.WriteLine("Invalid post id!");
                return;
            }

            var post = _db.Posts.Find(postId);

            if (post == null)
            {
                Console.WriteLine("Post not found!");
                return;
            }

            Console.Write("Enter new title: ");
            string newTitle = Console.ReadLine();

            Console.Write("Enter new body: ");
            string newBody = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newTitle))
                post.PostTitle = newTitle;

            if (!string.IsNullOrWhiteSpace(newBody))
                post.PostBody = newBody;

            _db.SaveChanges();

            Console.WriteLine("Post updated successfully.");
        }
    }
}
