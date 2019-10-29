using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using DevEK.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevEK.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotify _notify;


        public MainController(INotify notify)
        {
            _notify = notify;
        }


        //Validation of Erro's Notification
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            //If there is errors, add errors to Notify
            if (!modelState.IsValid) NotifiyFromErrorModel(modelState);
            return CustomResponse();
        }


        protected ActionResult CustomResponse(object result = null)
        {
            if (_notify.ThereIsNotification())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notify.GetNotifications().Select(n => n.Message)
                }); 
            }
            else
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });

            }
               
        }

      
        //Validation of ModelState
        protected void NotifiyFromErrorModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach(var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMessage);

            }
        }


        protected void NotifyError(string errorMessage)
        {
            _notify.Handle(new Notification(errorMessage));
        }
  
    }
}
