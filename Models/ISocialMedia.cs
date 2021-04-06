using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public interface ISocialMedia
    {
        public Task createPost(string message, byte[] media);
    }
}
