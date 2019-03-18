using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq_Test
{
    /// <summary>
    /// 英雄
    /// </summary>
    public interface IHero
    {
        /// <summary>
        /// 姓名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 血量
        /// </summary>
        int Red { get; set; }

        /// <summary>
        /// 蓝量
        /// </summary>
        int Blue { get; set; }

        /// <summary>
        /// 轻功
        /// </summary>
        int Fly { get; set; }

        /// <summary>
        /// 技能
        /// </summary>
        List<ISkill> Skills { get; set; }

        string GetName();
        bool SetName(string name);
        List<ISkill> GetSkill();
        bool AddSkill(ISkill skill);
        int GetRed();
        bool SetRed(int red);
        int GetBlue();
        bool SetBlue(int blue);

    }
}
