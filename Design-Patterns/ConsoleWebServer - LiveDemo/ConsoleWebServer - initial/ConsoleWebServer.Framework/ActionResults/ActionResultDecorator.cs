namespace ConsoleWebServer.Framework.ActionResults
{
    /* Декоратор патерн - надгражда класове с допълнителни методи
       1. Наследява интерфейса
       2. Подаваме му интерфейса в коструктора
     */
    public abstract class ActionResultDecorator : IActionResult
    {
        private readonly IActionResult actionResult;

        protected ActionResultDecorator(IActionResult actionResult)
        {
            this.actionResult = actionResult;
        }

        public HttpResponse GetResponse()
        {
            // 3. Извикваме си стандартната функционалност
            var response = this.actionResult.GetResponse();
            // 4. Извикваме допълнителната функционалност            
            this.UpdateResponse(response);
            return response;
        }

        // 5. Във всеки наследник се овъррайдва метода с различна допълнителна функционалност
        // 6. Наследниците наследяват този(абстрактния) клас
        protected abstract void UpdateResponse(HttpResponse response);
    }
}
