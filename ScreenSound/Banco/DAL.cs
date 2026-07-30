using Microsoft.EntityFrameworkCore;

namespace ScreenSound.Banco;

public class DAL<T> 
    where T : class
{
    protected readonly ScreenSoundContext _context;
    private readonly DbSet<T> _dbSet;

    public DAL(ScreenSoundContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> Listar()
    {
        return _dbSet.ToList();
    }

    public void Adicionar(T objeto)
    {
        _dbSet.Add(objeto);
        _context.SaveChanges();
    }

    public void Atualizar(T objeto)
    {
        _dbSet.Update(objeto);
        _context.SaveChanges();
    }

    public void Deletar(T objeto)
    {
        _dbSet.Remove(objeto);
        _context.SaveChanges();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return _dbSet.FirstOrDefault(condicao);
    }

    public IEnumerable<T> ListarPor(Func<T, bool> condicao)
    {
        return _dbSet.Where(condicao).ToList();
    }
}
