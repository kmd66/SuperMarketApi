﻿using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IInformationDataSource : IDataSource
    {
        Task<Result<Information>> AddAsync(Information model);

        Task<Result<IEnumerable<Information>>> ListAsync(InformationVM model);

    }
}
