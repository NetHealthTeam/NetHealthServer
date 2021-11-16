using NetHealthServer.Data.Entities;
using NetHealthServer.Errors;
using NetHealthServer.Model;
using NetHealthServer.Model.Response;
using NetHealthServer.Repo.Abstract;
using NetHealthServer.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Concrete
{
    public class DietService : IDietService
    {
        private readonly INutritionRepo nutritionRepo;

        public DietService(INutritionRepo nutritionRepo)
        {
            this.nutritionRepo = nutritionRepo;
        }
        public async Task<DietResponse> GetDailyDiet(User user)
        {
            var nutrition = user.NutritProgram;
            if (nutrition == null)
            {
                throw new CustomError("nutrition_not_found");
            }
            var dayOfWeek =(int) DateTime.Now.DayOfWeek;
            var diets = nutrition.Diets.FirstOrDefault(x => x.WeekDay == dayOfWeek);
            if (diets == null)
            {
                throw new CustomError("diet_not_found");
            }
            var meals = diets.Meals;
            if (meals == null)
            {
                throw new CustomError("meal_not_found");
            }
            //decimal firstMeal, secondMeal, thirdMeal, fourthMeal = 0;
            List<MealModel> mealModels = new List<MealModel>();
            decimal percentageOfMeal =(decimal) 0.4;


            if (user.NumberOfMeals == 4)
            {
                
                for (int i = 1; i < 5; i++)
                {
                    int timeOfDay = i;
                    if (i == 3)
                    {
                        timeOfDay = 2;
                    }else if (i == 4)
                    {
                        timeOfDay = 3;
                    }
                   var meal= meals.FirstOrDefault(x => x.TimeOfDay == timeOfDay);
                    if (i==3)
                    {
                         meal = meals.LastOrDefault(x => x.TimeOfDay == timeOfDay);

                    }

                    MealModel mealModel = new MealModel() { 
                        Name=meal.Name,
                        CaloryPerPorsion=meal.Calory,
                        TimeOfDay=meal.TimeOfDay,
                        ImageUrl=meal.ImageUrl,
                        MealUrl=meal.MealUrl,
                        Porsion= Math.Round((user.AmountOfCalories * percentageOfMeal) / meal.Calory * 2, MidpointRounding.AwayFromZero) / 2

                    };
                    mealModels.Add(mealModel);
                    percentageOfMeal = (decimal)0.2;


                }
            }
            else if (user.NumberOfMeals == 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    percentageOfMeal = (decimal)0.4;
                    if (i == 3)
                    {
                        percentageOfMeal = (decimal)0.2;


                    }
                    var meal = meals.FirstOrDefault(x => x.TimeOfDay == i);
                    MealModel mealModel = new MealModel()
                    {
                        Name = meal.Name,
                        CaloryPerPorsion = meal.Calory,
                        TimeOfDay = meal.TimeOfDay,
                        ImageUrl = meal.ImageUrl,
                        MealUrl = meal.MealUrl,
                        Porsion = Math.Round((user.AmountOfCalories * percentageOfMeal) / meal.Calory * 2, MidpointRounding.AwayFromZero) / 2 

                    };
                    mealModels.Add(mealModel);

                }
            }

            DietResponse dietResponse = new DietResponse();
            dietResponse.Meals = mealModels;
            return dietResponse;
        }
    }
}
