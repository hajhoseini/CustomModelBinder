using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomModelBinder.Models
{
    public class UserCustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var values = bindingContext.ValueProvider.GetValue("user");//مثلا user پارامتری است که در کوئری استرینگ ارسال می کنیم
            if(values.Length == 0)
            {
                return Task.CompletedTask;
            }

            var splitData = values.FirstValue.Split(new char[] {'|'});
            if(splitData.Length >= 3)
            {
                User user = new User()
                {
                    Id = int.Parse(splitData[0]),
                    Name = splitData[1],
                    Code = splitData[2],
                };
                bindingContext.Result = ModelBindingResult.Success(user);
            }
            
            return Task.CompletedTask;
        }
    }
}
