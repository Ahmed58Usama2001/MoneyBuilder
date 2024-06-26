﻿namespace MoneyBuilder.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly MoneyBuilderContext _multaqaTechContext;

    private Hashtable _repositories;

    public UnitOfWork(MoneyBuilderContext multaqaTechContext) //Ask CLR To create object from DB Context Implecitly
    {
        _multaqaTechContext = multaqaTechContext;
        _repositories = new Hashtable();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity  //This Method to create repository per request
    {
        var key = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(key))
        {
            var repository = new GenericRepository<TEntity>(_multaqaTechContext);
            _repositories.Add(key, repository);
        }

        return _repositories[key] as IGenericRepository<TEntity>;
    }
    public async Task<int> CompleteAsync()
        => await _multaqaTechContext.SaveChangesAsync();

    public async ValueTask DisposeAsync()
    => await _multaqaTechContext.DisposeAsync();
}