using AutoMapper;
using Backend.Models;

namespace Backend.Mappers
{
    public class MappingSoba : Mapping<Soba, SobaDTORead, SobaDTOInsertUpdate>
    {

        public MappingSoba()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Soba, SobaDTORead>()
                .ConstructUsing(entitet =>
                 new SobaDTORead(

                     entitet.sifra,
                    entitet.Oznaka,
                    entitet.Kapacitet
                    ));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<SobaDTOInsertUpdate, Soba>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Soba, SobaDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new SobaDTOInsertUpdate(
                   entitet.Oznaka,
                   entitet.Kapacitet
                  ));
            }));
        }

    }
}