using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Abstraction.IServices
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string picture, string pictureBase64);
    }
}
