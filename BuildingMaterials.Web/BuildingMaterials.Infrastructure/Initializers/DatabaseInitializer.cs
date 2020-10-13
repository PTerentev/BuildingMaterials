using AspNetCore.AsyncInitialization;
using BuildingMaterials.Infrastructure.DataAccess;
using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingMaterials.Infrastructure.Initializers
{
    public class DatabaseInitializer : IAsyncInitializer
    {
        private readonly AppDbContext appDbContext;

        public DatabaseInitializer(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task InitializeAsync()
        {
            await SeedPositionsAsync();
        }

        private async Task SeedPositionsAsync()
        {
            var positions = new List<Position>()
            {
                new Position()
                {
                    Name = "Композитный материа́л",
                    Description = "Многокомпонентный материал, изготовленный из двух или более компонентов с существенно различными физическими и/или химическими свойствами.",
                    Price = 350,
                    ImageUrl = "images/komposite.jpg"
                },
                new Position()
                {
                    Name = "Доска 20х146x2000",
                    Description = "Доска строганая 2 м применяется при строительстве и отделке домов, беседок, изготовлении мебели и предметов интерьера, ограждений для садовых участков, укладке полов. Пиломатериал изготовлен из бессучковой сосны. Массив плотный и прочный за счет содержащейся в хвойной древесине камеди, с красивым рисунком в распиле. - Сечение доски имеет форму прямоугольника, размер — 20х146 мм. - Длина доски — 2 м.",
                    Price = 250,
                    ImageUrl = "images/doski.jpg"
                },
                new Position()
                {
                    Name = "Каска строительная",
                    Description = "Средства индивидуальной защиты (СИЗ) головы — нашли широчайшее применение в самых различных областях, их активно используют строители и монтажники, шахтеры и военные, спортсмены и т.д.",
                    Price = 500,
                    ImageUrl = "images/kaska.jpg"
                },
                new Position()
                {
                    Name = "Бетон М100(В7,5)",
                    Description = "Такая строительная смесь готовится путём смешивания цемента марки М400, песка и щебня (гранитного или гравийного) в пропорции 1,0:4,6:7,0.",
                    Price = 1500,
                    ImageUrl = "images/rastvor.jpg"
                },
                new Position()
                {
                    Name = "Ячеистый бетон",
                    Description = "Искусственный пористый строительный материал на основе минеральных вяжущих и кремнезёмистого заполнителя.",
                    Price = 100,
                    ImageUrl = "images/yachistiyBeton.jpg"
                },
                new Position()
                {
                    Name = "Доска 40х146x3000 мм",
                    Description = "Доска строганая 3 м выполнена из прочного и плотного массива бессучковой сосны с мелкими узлами. Хвойная древесина содержит фитонциды, предотвращающие размножение бактерий, грибка и насекомых, и смолу, замедляющую процессы гниения.",
                    Price = 560,
                    ImageUrl = "images/doski2.jpg"
                },
            };

            appDbContext.Positions.AddRange(positions);
            await appDbContext.SaveChangesAsync();
        }
    }
}
