using System;

namespace ActionDemo
{
	public enum SkillType
	{
		None = 0,
		NormalAttack = 1,
		Dodge = 2,
	}

	/// <summary>
	/// 行動コマンド定義
	/// </summary>
	[Flags]
	public enum CharacterActionCommand
	{
		None = 0,
		Move = 1 << 0,
		Dodge = 1 << 1,
		NormalAttack = 1 << 2,
		All = ~0,
	}

	/// <summary>
	/// 先行入力可能な行動コマンド定義
	/// </summary>
	public enum InputBufferingActionCommand
	{
		None = 0,
		Dodge = 1 << 0,
		NormalAttack = 1 << 1,
		All = ~0,
	}
}
