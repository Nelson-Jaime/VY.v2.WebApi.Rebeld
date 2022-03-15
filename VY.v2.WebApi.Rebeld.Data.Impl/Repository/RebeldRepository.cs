using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.v2.WebApi.Rebeld.Data.Contracts.Entities;
using VY.v2.WebApi.Rebeld.Data.Contracts.Repository;

namespace VY.v2.WebApi.Rebeld.Data.Impl.Repository
{
    public class RebeldRepository : IRebeldRepository
    {
        
        private readonly string _path;

        public RebeldRepository(string path)
        {
            _path = path;
        }

        internal virtual async Task AppendTextAsync(string data)
        {
            await File.AppendAllTextAsync(_path, data);
        }

        internal virtual async Task WriteAllTextAsync(IEnumerable<string> lines)
        {
            await File.WriteAllLinesAsync(_path, lines);
        }

        internal virtual async Task<string[]> ReadAllLinesAsync()
        {
            return await File.ReadAllLinesAsync(_path);
        }

        public async Task<RebeldEntity> AddAsync(RebeldEntity rebeld)
        {
            rebeld.Id = Guid.NewGuid();
            string data = string.Format("Id:{0}; Name:{1}; Planet:{2}; Created:{3} **\n", rebeld.Id, rebeld.Name, rebeld.Planet, rebeld.Created);
            await AppendTextAsync(data);
            return rebeld;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            bool found = false;
            var lines = (await ReadAllLinesAsync()).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split('*');
                if (parts[0] == id.ToString())
                {
                    lines.RemoveAt(i);
                    found = true;
                    break;
                }
            }
            await WriteAllTextAsync(lines);
            return found;
        }

        public async Task<RebeldEntity> GetAsync(Guid id)
        {
            string[] lines = await ReadAllLinesAsync();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('*');
                if (parts[0] == id.ToString())
                {
                    return new RebeldEntity { Id = Guid.Parse(parts[0]), Name = parts[1], Planet = parts[2], Created = DateTime.Parse(parts[3]) };
                }
            }
            return null;

        }

        public async Task<IEnumerable<RebeldEntity>> GetAllAsync()
        {
            List<RebeldEntity> list = new List<RebeldEntity>();

            string[] lines = await ReadAllLinesAsync();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                var person = new RebeldEntity { Id = Guid.Parse(parts[0]), Name = parts[1], Planet = parts[2], Created = DateTime.Parse(parts[3]) };
                list.Add(person);
            }

            return list;
        }

        public async Task<bool> UpdateAsync(RebeldEntity rebeld)
        {
            bool found = false;

            string[] lines = await ReadAllLinesAsync();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts[0] == rebeld.Id.ToString())
                {
                    lines[i] = string.Format("Id:{0}; Name:{1}; Planet:{2}; Created:{3} **\n", rebeld.Id, rebeld.Name, rebeld.Planet, rebeld.Created);
                    found = true;
                    break;
                }
            }
            await WriteAllTextAsync(lines);
            return found;
        }
    }
}
