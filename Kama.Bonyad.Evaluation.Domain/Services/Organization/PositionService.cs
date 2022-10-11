using System;
using System.Text;
using System.Threading.Tasks;
using Kama.Library.Helper;
using System.Collections.Generic;
using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Service;
using Kama.Bonyad.Evaluation.Core.Model;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Kama.Organization.Core.Model;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class PositionService : Service, Core.Service.IPositionService
    {
        public PositionService(AppCore.IOC.IContainer container,
            Organization.ApiClient.Interface.IPositionService positionService,
            Organization.ApiClient.Interface.IDepartmentService departmentService,
            Core.IRequestInfo requestInfo): base(container)
        {
            _positionService = positionService;
            _departmentService = departmentService;
            _requestInfo = requestInfo;
        }

        private readonly Organization.ApiClient.Interface.IPositionService _positionService;
        private readonly Organization.ApiClient.Interface.IDepartmentService _departmentService;
        private readonly Core.IRequestInfo _requestInfo;

        public async Task<AppCore.Result<Organization.Core.Model.Position>> AddAsync(Organization.Core.Model.Position model)
        {
            var validation = await _ValidateForSaveAsync(model);
            if (!validation.Success)
                return AppCore.Result<Organization.Core.Model.Position>.Failure(message: validation.Message);

            return await _positionService.Add(model, null);
        }

        public async Task<AppCore.Result<Organization.Core.Model.Position>> EditAsync(Organization.Core.Model.Position model)
        {
            var validation = await _ValidateForSaveAsync(model);
            if (!validation.Success)
                return AppCore.Result<Organization.Core.Model.Position>.Failure(message: validation.Message);

            return await _positionService.Edit(model, null);
        }

        public async Task<Result<IEnumerable<EvaluationPosition>>> ListAsync(Organization.Core.Model.PositionListVM model)
        {
            var positionListResult = await _positionService.List(model);
            if (!positionListResult.Success)
                return Result<IEnumerable<EvaluationPosition>>.Failure(message: positionListResult.Message);
            var positionListData = positionListResult.Data;

            var positionList = new List<EvaluationPosition>();

            foreach (var item in positionListData)
            {
                positionList.Add(new EvaluationPosition()
                {
                    ID = item.ID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Type = item.Type,
                    Username = item.Username,
                    DepartmentName = item.DepartmentName,
                    NationalCode = item.NationalCode
                });
            }

            return Result<IEnumerable<EvaluationPosition>>.Successful(data: positionList);
        }

        public async Task<AppCore.Result> DeleteAsync(Guid id)
        {
            var validationResult = await _ValidateForDelete(id);
            if (!validationResult.Success)
                return AppCore.Result.Failure(message: validationResult.Message);

            return await _positionService.Delete(id);
        }

        private async Task<AppCore.Result> _ValidateForSaveAsync(Organization.Core.Model.Position model)
        {
            /*if (model.UserID != null)
            {
                var listResult = await _positionService.List(new Organization.Core.Model.PositionListVM { UserID = model.UserID });
                if (!listResult.Success)
                    return listResult;
                var userCurrentpositions = listResult.Data.ToList();

                if (userCurrentpositions.Any(p => p.ID != model.ID && p.Type == model.Type && p.DepartmentID == model.DepartmentID))
                    return AppCore.Result.Failure(message: $"این کاربر قبلا در این سمت ثبت شده است. امکان ثبت سمت جدید وجود ندارد");

                var positionType = (Organization.Core.Model.EvaluationPositionType)byte.Parse(model.Type.ToString("d"));
                if (!(positionType == Organization.Core.Model.EvaluationPositionType./*راهبر*//*
                    || positionType == Organization.Core.Model.EvaluationPositionType.*//*کارشناس_استخدام_سازمان_اداری_و_استخدامی_کشور*//*
                    || positionType == Organization.Core.Model.EvaluationPositionType.*//*مسئول_صدور_شماره*//*
                    || positionType == Organization.Core.Model.EvaluationPositionType.*//*کارگزین*//*
                    || positionType == Organization.Core.Model.EvaluationPositionType.*//*ذیحساب*//*))
                {
                    if (userCurrentpositions.Any(p => p.ID != model.ID))
                        return AppCore.Result.Failure(message: $"برای این کاربر قبلا سمتی ثبت شده است ({((Organization.Core.Model.EvaluationPositionType)byte.Parse(userCurrentpositions.FirstOrDefault().Type.ToString("d"))).ToString()} {userCurrentpositions.FirstOrDefault().DepartmentName.ToString()}). امکان ثبت سمت جدید وجود ندارد");
                }

                if (positionType == Organization.Core.Model.EvaluationPositionType.*//*ذیحساب*//*
                    && userCurrentpositions.Any(p => (Organization.Core.Model.EvaluationPositionType)byte.Parse(p.Type.ToString("d")) != Organization.Core.Model.EvaluationPositionType.*//*ذیحساب*//*))
                    return AppCore.Result.Failure(message: $"برای این کاربر قبلا سمتی ثبت شده است ({((Organization.Core.Model.EvaluationPositionType)byte.Parse(userCurrentpositions.FirstOrDefault().Type.ToString("d"))).ToString()} {userCurrentpositions.FirstOrDefault().DepartmentName.ToString()}). امکان ثبت سمت جدید وجود ندارد");

                if (positionType == Organization.Core.Model.EvaluationPositionType.*//*کارگزین*//*
                    && userCurrentpositions.Any(p => (Organization.Core.Model.EvaluationPositionType)byte.Parse(p.Type.ToString("d")) == Organization.Core.Model.EvaluationPositionType.*//*کارگزین*//* && p.ID != model.ID))
                    return AppCore.Result.Failure(message: $"برای این کاربر قبلا سمتی ثبت شده است ({((Organization.Core.Model.EvaluationPositionType)byte.Parse(userCurrentpositions.FirstOrDefault().Type.ToString("d"))).ToString()} {userCurrentpositions.FirstOrDefault().DepartmentName.ToString()}). امکان ثبت سمت جدید وجود ندارد");
            }
            else
            {
                var positionListResult = await _positionService.List(new Organization.Core.Model.PositionListVM { DepartmentId = model.DepartmentID });
                if (!positionListResult.Success)
                    return positionListResult;
                var positionResult = positionListResult.Data;

                if (positionResult.Any(d => (byte)d.Type == (byte)model.Type && d.ID != model.ID
                && ((byte)model.Type != (byte)Organization.Core.Model.EvaluationPositionType.*//*کارشناس_استخدام_سازمان_اداری_و_استخدامی_کشور*//*
                    && (byte)model.Type != (byte)Organization.Core.Model.EvaluationPositionType.*//*مسئول_صدور_شماره*//*
                    && (byte)model.Type != (byte)Organization.Core.Model.EvaluationPositionType.*//*کارشناس*//*
                    && (byte)model.Type != (byte)Organization.Core.Model.EvaluationPositionType.*//*کارگزین*//*
                    && (byte)model.Type != (byte)Organization.Core.Model.EvaluationPositionType.*//*راهبر*//*)))
                    return AppCore.Result<Guid>.Failure(message: $"این سمت قبلا ثبت شده است و امکان ثبت مجدد وجود ندارد.");

            }*/
            return AppCore.Result.Successful();
        }

        private async Task<AppCore.Result> _ValidateForDelete(Guid id)
        {
            /*#region get Position
            var positionResult = await _positionService.Get((Guid)_requestInfo.PositionId);
            if (!positionResult.Success)
                return AppCore.Result.Failure(message: positionResult.Message);
            var position = positionResult.Data;
            #endregion

            if (!new[] {
                (byte)Organization.Core.Model.EvaluationPositionType.راهبر
            }.Contains((byte)position.Type))
            {
                return AppCore.Result<Core.Model.Complaint>.Failure(message: "شما مجوز حذف جایگاه را ندارید.");
            }

            var result = await _requestDataSource.CheckHasPositionCartableAsync(id);
            if (!result.Success)
                return AppCore.Result.Failure(message: result.Message);
            var hasRequestcartable = result.Data;

            if (hasRequestcartable.HasCartable)
                return AppCore.Result<Core.Model.Complaint>.Failure(message: "کارتابل جایگاه مورد نظر خالی نمی باشد ، بنابراین امکان حذف جایگاه را ندارید.");*/


            return AppCore.Result.Successful();
        }
    }
}
