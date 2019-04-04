using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Auditing.Dto;
using GSoft.AbpZeroTemplate.Dto;

namespace GSoft.AbpZeroTemplate.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
