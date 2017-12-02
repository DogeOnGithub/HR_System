using EnumState;
using System;

namespace Model
{
    public class Staff
    {

        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 外键,3级机构id
        /// </summary>
        public int ThirdOrgId { get; set; }

        /// <summary>
        /// 外键,职位名称id,即OccupationName.id
        /// </summary>
        public int OccId { get; set; }

        /// <summary>
        /// 外键,薪酬标准id
        /// </summary>
        public int StandardId { get; set; }

        /// <summary>
        /// 外键,职称id
        /// </summary>
        public int TechnicalTitleId { get; set; }

        public string StaffName { get; set; }           //姓名
        public int Sex { get; set; }                    //性别
        public string Email { get; set; }               //邮箱
        public string Phone { get; set; }               //电话
        public string Qq { get; set; }                  //QQ
        public string CellPhone { get; set; }           //手机
        public string StaffAdress { get; set; }         //地址  
        public string PostalCode { get; set; }          //邮政编码
        public string Nationality { get; set; }         //国籍
        public string Birthland { get; set; }           //出生地
        public DateTime DateOfBirth { get; set; }       //出生日期
        public string Nation { get; set; }              //民族
        public string ReligiousBelief { get; set; }     //宗教信仰
        public string Politics { get; set; }            //政治面貌
        public string IdNumber { get; set; }            //身份证号码
        public string SocialSecurityNumber { get; set; }//社会安全保障号码
        public int Age { get; set; }                    //年龄
        public string Education { get; set; }           //学历
        public string Specialty { get; set; }           //专业
        public string Bank { get; set; }                //开户行
        public string BankNumber { get; set; }          //银行账号
        public string Speciality { get; set; }          //特长
        public string Hobby { get; set; }               //爱好
        public string PersonResume { get; set; }        //个人履历
        public string FamilyInfo { get; set; }          //家庭信息
        public string PersonDesc { get; set; }          //备注
                 
        /// <summary>
        /// 头像路径
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        public string Registrant { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime RegistTime { get; set; }

        /// <summary>
        /// 员工档案号
        /// </summary>
        public string StaffFileNumber { get; set; }

        /// <summary>
        /// 档案状态,枚举类型,待审核或已审核
        /// </summary>
        public StaffFileStateEnum FileState { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckBy { get; set; }

    }
}
