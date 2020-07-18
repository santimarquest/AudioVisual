using AudioVisual.Domain.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisual.NetCoreFilters
{
    public class CustomResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting (ResultExecutingContext context)
        {
            var billboard = (AudioVisual.Domain.Contracts.BillBoard)((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result).Value;
            var weeks = ((Microsoft.AspNetCore.Http.HttpRequest)((Microsoft.AspNetCore.Http.DefaultHttpContext)context.HttpContext).Request).Query["billboardOptions.weeks"];
            Int32.TryParse(weeks, out int numberOfWeeks);

            billboard.MoviesForBigRooms = GenerateSchedule(billboard.MoviesForBigRooms, numberOfWeeks, billboard.NumberOfBigRooms);
            billboard.MoviesForSmallRooms = GenerateSchedule(billboard.MoviesForSmallRooms, numberOfWeeks, billboard.NumberOfSmallRooms);
        }
        public void OnResultExecuted (ResultExecutedContext context)
        {
            
        }

        private static List<string> GenerateSchedule(List<string> movies, int numberOfWeeks, int numberOfRooms)
        {
            var weekItem = 0;
            var roomItem = 0;

            var result = new List<string>();

            foreach (var item in movies)
            {
                result.Add($"[semana {(weekItem % numberOfWeeks) + 1}, sala {(roomItem % numberOfRooms) + 1}, {item}]");

                roomItem += 1;
                if (roomItem % numberOfRooms == 0)
                {
                    weekItem += 1;
                }
            }
            return result;
        }
    }
}
