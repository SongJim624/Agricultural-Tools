using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropModelMKS
{
    interface IWrapper
    {
        void Description(string path);
        void Convert(string file_path, string xml_path);
    }
}
