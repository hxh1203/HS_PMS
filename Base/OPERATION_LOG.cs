using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using PermissionManagementSystem.Models;
using SqlSugar;

namespace PermissionManagementSystem.Base
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("OPERATION_LOG")]
    public partial class OPERATION_LOG : ObservableObject
    {
        public OPERATION_LOG()
        {

        }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public virtual int RecordId { get; set; }
        public string UserName { get; set; }
        public string OperationType { get; set; }
        public string OperationInfo { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
