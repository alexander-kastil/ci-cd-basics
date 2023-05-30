using System;
using System.Collections.Generic;
using FoodApi;
using FoodApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FoodApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        FoodConfig config { get; set; }
        public MailController(IOptions<FoodConfig> cfg)
        {
            config = (FoodConfig)cfg.Value;
        }

        [HttpGet]
        [Route("sendMail")]
        public ActionResult SendMail()
        {
            FoodApp.GraphHelper.Send("Hello World", "A msg from me", new[] { "alexander.pajer@integrations.at" }, config);
            return Ok();
        }
    }
}