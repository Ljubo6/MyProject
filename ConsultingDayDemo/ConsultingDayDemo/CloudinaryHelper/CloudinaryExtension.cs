﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultingDayDemo.CloudinaryHelper
{
    public class CloudinaryExtension
    {
        public static async Task<List<string>> UploadAsync(Cloudinary cloudinary,ICollection<IFormFile> files)
        {
            List<string> list = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName,destinationStream)
                    };

                    var result = await cloudinary.UploadAsync(uploadParams);

                    list.Add(result.Uri.AbsoluteUri);
                }   
            }

            return list;
        }
    }
}
