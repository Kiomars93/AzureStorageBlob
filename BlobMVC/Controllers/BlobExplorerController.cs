using BlobMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobMVC.Controllers
{
    //[Route ("blobs")]
    [Route ("[Controller]")]
    public class BlobExplorerController : Controller
    {
        private readonly IBlobService _blobService;
        public BlobExplorerController(IBlobService blobService)
        {
            _blobService = blobService;
        }



        //[HttpGet("list")]
        public async Task<IActionResult> Index()
        {
            return View(await _blobService.ListBlobAsync());
        }
    }
}
