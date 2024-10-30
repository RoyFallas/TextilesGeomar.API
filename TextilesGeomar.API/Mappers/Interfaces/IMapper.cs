namespace TextilesGeomar.API.Mappers.Interfaces
{
    public interface IMapper<TEntity, TDto>
    {
        TDto MapToDto(TEntity entity);
        TEntity MapToEntity(TDto dto);
        IEnumerable<TDto> Map(IEnumerable<TEntity> entities);
    }
}
