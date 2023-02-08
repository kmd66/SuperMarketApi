using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class TagDataSource : DataSource, Core.DataSource.ITagDataSource
    {
        public TagDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<Result<Tag>> AddAsync(Tag model)
        {
            try
            {
                var result = (await _dbPBL.AddTagAsync(
                    _itemID: model.ItemID,
                    _tag: model.TagName
                    )).ToActionResult<Core.Model.Tag>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result> DeleteAsync(Tag model)
        {
            try
            {
                var result = (await _dbPBL.DeleteTagAsync(
                    _itemID: model.ItemID,
                    _tagID: model.TagID
                    )).ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Tag>>> ListAsync(TagVM model)
        {
            try
            {
                var result = (await _dbPBL.GetTagsAsync(
                    _itemID: model.ItemID
                    )).ToListActionResult<Tag>();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
