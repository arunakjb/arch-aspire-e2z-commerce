using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class TransactionsEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/transactions", auth: "Policy", tags: ["Transactions"]);
            endPoint.MapGet("/get/{id}", (ITransactionService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (ITransactionService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (ITransactionService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (ITransactionService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (ITransactionService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(ITransactionService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(ITransactionService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(ITransactionService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(ITransactionService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(ITransactionService service)
        {
            throw new NotImplementedException();
        }
    }
}
