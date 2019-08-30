using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSchedulerApi.Models.Repository;

namespace TaskSchedulerApi.Models.DataManager
{
    public class TaskManager : IDataRepository<Task>
    {
        readonly TaskContext _taskContext;

        public TaskManager(TaskContext context)
        {
            _taskContext = context;
        }
        public void Add(Task entity)
        {
            _taskContext.Tarefas.Add(entity);
            _taskContext.SaveChanges();
        }

        public void Delete(Task entity)
        {
            _taskContext.Tarefas.Remove(entity);
            _taskContext.SaveChanges();
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskContext.Tarefas.ToList();
        }

        public Task GetById(long id)
        {
            return _taskContext.Tarefas
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Task dbEntity, Task entity)
        {
            dbEntity.Status = entity.Status;
            dbEntity.Titulo = entity.Titulo;
            dbEntity.Descricao = entity.Descricao;
            _taskContext.SaveChanges();
        }

        public void UpdateStatus(long entityId, bool status)
        {
            var tarefa = GetById(entityId);
            tarefa.Status = status;
            _taskContext.SaveChanges();
        }
    }
}
