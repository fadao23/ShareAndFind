using System;
namespace FindAndShare.Models
{
    public class AnnoncePostModel
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public string ID { get; set; }
        public string Image { get; set; }


        public void Fill(string title, string text, string image)
        {
            this.Title = title;
            this.Text = text;
            this.Image = image;
        }
    }
}
