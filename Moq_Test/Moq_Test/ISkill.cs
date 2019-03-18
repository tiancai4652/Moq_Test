using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq_Test
{
    /// <summary>
    /// 技能
    /// </summary>
    public interface ISkill
    {
        /// <summary>
        /// 蓝量
        /// </summary>
        int Blue { get; set; }

        /// <summary>
        /// 伤害
        /// </summary>
        int Hurt { get; set; }
    }
}
