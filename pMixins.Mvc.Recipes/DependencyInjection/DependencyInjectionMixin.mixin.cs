//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by CopaceticSoftware.pMixins.CodeGenerator v0.1.13.352
//      for file D:\Projects\sandbox\pMixins\pMixins.Mvc.Recipes\DependencyInjection\DependencyInjectionMixin.cs.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.  
// </auto-generated> 
//------------------------------------------------------------------------------
namespace pMixins.Mvc.Recipes.DependencyInjection
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
	public partial class DependencyInjectionMixinExample : global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixinExample.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin.IDependencyInjectionMixinRequirements, global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin>
	{
		[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
		private sealed class __Mixins
		{
			public static global::System.Object ____Lock = new global::System.Object ();
			public readonly __pMixinAutoGenerated.pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin.DependencyInjectionMixinMasterWrapper pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin;
			public __Mixins (DependencyInjectionMixinExample host)
			{
				pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin = global::CopaceticSoftware.pMixins.Infrastructure.MixinActivatorFactory.GetCurrentActivator ().CreateInstance<__pMixinAutoGenerated.pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin.DependencyInjectionMixinMasterWrapper> ((global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixinExample.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin.IDependencyInjectionMixinRequirements)host);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			public void __ActivateMixinDependencies (DependencyInjectionMixinExample host)
			{
				pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin.__ActivateMixinDependencies (host);
			}
		}
		private __Mixins _____mixins;
		private __Mixins ___mixins {
			get {
				if (null == _____mixins) {
					lock (__Mixins.____Lock) {
						if (null == _____mixins) {
							_____mixins = new __Mixins (this);
							_____mixins.__ActivateMixinDependencies (this);
						}
					}
				}
				return _____mixins;
			}
		}
		[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
		private sealed class __pMixinAutoGenerated
		{
			[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
			public sealed class pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin
			{
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
				public abstract class DependencyInjectionMixinProtectedMembersWrapper : global::pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin
				{
					public DependencyInjectionMixinProtectedMembersWrapper (global::System.String activator) : base (activator)
					{
					}
				}
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
				public class DependencyInjectionMixinAbstractWrapper : DependencyInjectionMixinProtectedMembersWrapper
				{
					private readonly global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixinExample.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin.IDependencyInjectionMixinRequirements _target;
					public DependencyInjectionMixinAbstractWrapper (global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixinExample.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin.IDependencyInjectionMixinRequirements target, global::System.String activator) : base (activator)
					{
						_target = target;
					}
				}
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
				public sealed class DependencyInjectionMixinMasterWrapper : global::CopaceticSoftware.pMixins.Infrastructure.MasterWrapperBase
				{
					public readonly global::pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin _mixinInstance;
					public DependencyInjectionMixinMasterWrapper (global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixinExample.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin.IDependencyInjectionMixinRequirements mixinInstance)
					{
						_mixinInstance = base.TryActivateMixin<__pMixinAutoGenerated.pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin.DependencyInjectionMixinAbstractWrapper> (mixinInstance);
						base.Initialize (mixinInstance, _mixinInstance, new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.IMixinInterceptor> {

						});
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					public void __ActivateMixinDependencies (DependencyInjectionMixinExample target)
					{
					}
					internal global::System.String Activator {
						get {
							return base.ExecutePropertyGet ("Activator", () => _mixinInstance.Activator);
						}
					}
				}
			}
		}
		public global::System.String Activator {
			get {
				return ___mixins.pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin.Activator;
			}
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public static implicit operator global::pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin (DependencyInjectionMixinExample target) {
			return target.___mixins.pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin._mixinInstance;
		}
		global::pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin>.MixinInstance {
			get {
				return ___mixins.pMixins_Mvc_Recipes_DependencyInjection_DependencyInjectionMixin._mixinInstance;
			}
		}
	}
}
namespace pMixins.AutoGenerated.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixinExample.pMixins.Mvc.Recipes.DependencyInjection.DependencyInjectionMixin
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.352")]
	public interface IDependencyInjectionMixinRequirements
	{
	}
}
