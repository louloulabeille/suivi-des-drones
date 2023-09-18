namespace suivie_des_drones.Cores.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        public ICollection<T> GetAll();
        public ICollection<T> GetAllNoTracking();
        public T? GetById(int id);
        public void Add(T item);
        public void Remove(T item);
        public void RemoveAll();
        public T? GetById(string id);
        public void AddRange(ICollection<T> items);
        public int Save();
        public void DetecteChange();
    }
}