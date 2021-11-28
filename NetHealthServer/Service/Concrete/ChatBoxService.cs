using NetHealthServer.Data.Entities;
using NetHealthServer.Errors;
using NetHealthServer.Model.Request;
using NetHealthServer.Model.Response;
using NetHealthServer.Service.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Concrete
{
    public class ChatBoxService : IChatBoxService
    {
        private readonly IDietService dietService;
        private readonly IGymService gymService;

        public ChatBoxService(IDietService dietService,IGymService gymService)
        {
            this.dietService = dietService;
            this.gymService = gymService;
        }
        public async Task<ChatBoxResponse> GetChatBoxResponse(ChatBoxRequest chatBoxRequest, User user)

        {
            var finalResponse = new ChatBoxResponse();
            var jsonInString = JsonConvert.SerializeObject(chatBoxRequest);
            var client = new HttpClient();
            var result = await client.PostAsync("https://workoutdiet.herokuapp.com/predict", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            var contentModel = JsonConvert.DeserializeObject<ChatBoxApiResponse>(content);
            if (contentModel.date == null)
            {
                throw new CustomError("message_not_correct");
            }
            contentModel.date = (contentModel.date + 1) % 7;
            var categories = contentModel.category.Split(" ");
            if (categories[0] == "diet")
            {
              var diet =   user.NutritProgram.Diets.FirstOrDefault(x => x.WeekDay == contentModel.date);
                var dietResponse = await dietService.GetDailyDiet(user, contentModel.date);
                finalResponse.DietResponse = dietResponse;
            }else if (categories[0] == "workout")
            {
                var gyms = await gymService.GetGymProgram(user, contentModel.date);
                ExerciseResponse exerciseResponse = new ExerciseResponse()
                {
                    Exercises = gyms
                };
                finalResponse.ExerciseResponse = exerciseResponse;
            }
            return finalResponse;

        }
    }
}
