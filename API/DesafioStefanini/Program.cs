using DesafioStefanini.Models;
using DesafioStefanini.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MyDb"));
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IItemService, ItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//var tarefas = new List<Tarefa>
//{
//    new Tarefa { Id = 1, Titulo = "Título 1", Descricao = "Desc 1", DataCriacao = DateTime.Now, Status = Status.Pendente },
//    new Tarefa { Id = 2, Titulo = "Título 2", Descricao = "Desc 2", DataCriacao = DateTime.Now, Status = Status.EmAndamento },
//    new Tarefa { Id = 3, Titulo = "Título 3", Descricao = "Desc 3", DataCriacao = DateTime.Now, Status = Status.Concluida }
//};

//app.MapGet("/tarefa", () =>
//{
//    return tarefas;
//});

//app.MapGet("/tarefa/{id}", (int id) =>
//{
//    var tarefa = tarefas.Find(t => t.Id == id);
//    if (tarefa is null)
//        return Results.NotFound("Desculpe, tarefa não encontrada...");

//    return Results.Ok(tarefa);
//});

//app.MapPost("/tarefa", (Tarefa tarefa) =>
//{
//    tarefas.Add(tarefa);
//    return tarefas;
//});

//app.MapPut("/tarefa/{id}", (Tarefa tarefaAtualizada, int id) =>
//{
//    var tarefa = tarefas.Find(t => t.Id == id);
//    if (tarefa is null)
//        return Results.NotFound("Desculpe, tarefa não encontrada...");

//    tarefa.Titulo = tarefaAtualizada.Titulo;
//    tarefa.Descricao = tarefaAtualizada.Descricao;
//    tarefa.DataCriacao = tarefaAtualizada.DataCriacao;
//    tarefa.Status = tarefaAtualizada.Status;

//    return Results.Ok(tarefa);
//});

//app.MapDelete("/tarefa/{id}", (int id) =>
//{
//    var tarefa = tarefas.Find(t => t.Id == id);
//    if (tarefa is null)
//        return Results.NotFound("Desculpe, tarefa não encontrada...");

//    tarefas.Remove(tarefa);

//    return Results.Ok(tarefa);
//});

app.Run();

//class Tarefa
//{
//    public int Id { get; set; }
//    public required string Titulo { get; set; }
//    public required string Descricao { get; set; }
//    public DateTime DataCriacao { get; set; }
//    public Status Status { get; set; }
//}

//enum Status
//{
//    Pendente,
//    EmAndamento,
//    Concluida
//}