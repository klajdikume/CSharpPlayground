using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Delegates
{
    public class Delegates
    {
        // An object that knows how to call a method
        // a reference to a function

    }

    public class Photo
    {
        public string Name { get; set; }

        public static Photo Load(string path)
        {
            var photo = new Photo
            {
                Name = "Abc"
            };

            return photo;
        }

        public void Save()
        {

        }
    }

    public class PhotoProcessor
    {
        // define the signature
        public delegate void PhotoFilterHandler(Photo photo);
        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            // save foto

            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();

        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }
        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply contrast");
        }
        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }
    }
}
