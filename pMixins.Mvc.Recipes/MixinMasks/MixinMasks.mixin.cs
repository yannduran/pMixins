//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by CopaceticSoftware.pMixins.CodeGenerator v0.1.13.355
//      for file D:\Projects\sandbox\pMixins\pMixins.Mvc.Recipes\MixinMasks\MixinMasks.cs.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.  
// </auto-generated> 
//------------------------------------------------------------------------------
namespace pMixins.Mvc.Recipes.MixinMasks
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
	public partial class ExampleTestMyEntityRepository : global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.ExampleTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements, global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity>>, global::pMixins.Mvc.Recipes.Repository.ICreate<global::pMixins.Mvc.Recipes.Repository.MyEntity>, global::pMixins.Mvc.Recipes.Repository.IReadById<global::pMixins.Mvc.Recipes.Repository.MyEntity>
	{
		[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
		private sealed class __Mixins
		{
			public static global::System.Object ____Lock = new global::System.Object ();
			public readonly __pMixinAutoGenerated.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__;
			public __Mixins (ExampleTestMyEntityRepository host)
			{
				pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ = global::CopaceticSoftware.pMixins.Infrastructure.MixinActivatorFactory.GetCurrentActivator ().CreateInstance<__pMixinAutoGenerated.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper> ((global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.ExampleTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements)host);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			public void __ActivateMixinDependencies (ExampleTestMyEntityRepository host)
			{
				pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.__ActivateMixinDependencies (host);
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
		[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
		private sealed class __pMixinAutoGenerated
		{
			[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
			public sealed class pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__
			{
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
				public abstract class InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ProtectedMembersWrapper : global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity>
				{
					public InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ProtectedMembersWrapper () : base ()
					{
					}
				}
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
				public class InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__AbstractWrapper : InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ProtectedMembersWrapper
				{
					private readonly global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.ExampleTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements _target;
					public InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__AbstractWrapper (global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.ExampleTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements target)
					{
						_target = target;
					}
				}
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
				public sealed class InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper : global::CopaceticSoftware.pMixins.Infrastructure.MasterWrapperBase
				{
					public readonly global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity> _mixinInstance;
					public InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper (global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.ExampleTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements mixinInstance)
					{
						_mixinInstance = base.TryActivateMixin<__pMixinAutoGenerated.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__AbstractWrapper> (mixinInstance);
						base.Initialize (mixinInstance, _mixinInstance, new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.IMixinInterceptor> {

						});
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					public void __ActivateMixinDependencies (ExampleTestMyEntityRepository target)
					{
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					internal global::System.Boolean Create (global::pMixins.Mvc.Recipes.Repository.MyEntity entity)
					{
						return base.ExecuteMethod ("Create", new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.Parameter> {
							new global::CopaceticSoftware.pMixins.Interceptors.Parameter {
								Name = "entity",
								Type = typeof(global::pMixins.Mvc.Recipes.Repository.MyEntity),
								Value = entity
							}
						}, () => _mixinInstance.Create (entity));
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					internal global::pMixins.Mvc.Recipes.Repository.MyEntity ReadById (global::System.Int32 id)
					{
						return base.ExecuteMethod ("ReadById", new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.Parameter> {
							new global::CopaceticSoftware.pMixins.Interceptors.Parameter {
								Name = "id",
								Type = typeof(global::System.Int32),
								Value = id
							}
						}, () => _mixinInstance.ReadById (id));
					}
				}
			}
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public global::System.Boolean Create (global::pMixins.Mvc.Recipes.Repository.MyEntity entity)
		{
			return ___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.Create (entity);
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public global::pMixins.Mvc.Recipes.Repository.MyEntity ReadById (global::System.Int32 id)
		{
			return ___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.ReadById (id);
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public static implicit operator global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity> (ExampleTestMyEntityRepository target) {
			return target.___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__._mixinInstance;
		}
		global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity> global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity>>.MixinInstance {
			get {
				return ___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__._mixinInstance;
			}
		}
	}
}
namespace pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.ExampleTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
	public interface IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements
	{
	}
}
namespace pMixins.Mvc.Recipes.MixinMasks
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
	public partial class AnotherTestMyEntityRepository : global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.AnotherTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements, global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity>>, global::pMixins.Mvc.Recipes.MixinMasks.IExampleTestMyEntityRepositoryMixinMask, global::pMixins.Mvc.Recipes.Repository.ICreate<global::pMixins.Mvc.Recipes.Repository.MyEntity>, global::pMixins.Mvc.Recipes.Repository.IReadById<global::pMixins.Mvc.Recipes.Repository.MyEntity>
	{
		[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
		private sealed class __Mixins
		{
			public static global::System.Object ____Lock = new global::System.Object ();
			public readonly __pMixinAutoGenerated.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__;
			public __Mixins (AnotherTestMyEntityRepository host)
			{
				pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ = global::CopaceticSoftware.pMixins.Infrastructure.MixinActivatorFactory.GetCurrentActivator ().CreateInstance<__pMixinAutoGenerated.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper> ((global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.AnotherTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements)host);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			public void __ActivateMixinDependencies (AnotherTestMyEntityRepository host)
			{
				pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.__ActivateMixinDependencies (host);
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
		[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
		private sealed class __pMixinAutoGenerated
		{
			[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
			public sealed class pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__
			{
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
				public abstract class InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ProtectedMembersWrapper : global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity>
				{
					public InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ProtectedMembersWrapper () : base ()
					{
					}
				}
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
				public class InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__AbstractWrapper : InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__ProtectedMembersWrapper
				{
					private readonly global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.AnotherTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements _target;
					public InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__AbstractWrapper (global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.AnotherTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements target)
					{
						_target = target;
					}
				}
				[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
				public sealed class InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper : global::CopaceticSoftware.pMixins.Infrastructure.MasterWrapperBase
				{
					public readonly global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity> _mixinInstance;
					public InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__MasterWrapper (global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.AnotherTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository.IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements mixinInstance)
					{
						_mixinInstance = base.TryActivateMixin<__pMixinAutoGenerated.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__AbstractWrapper> (mixinInstance);
						base.Initialize (mixinInstance, _mixinInstance, new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.IMixinInterceptor> {

						});
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					public void __ActivateMixinDependencies (AnotherTestMyEntityRepository target)
					{
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					internal global::System.Boolean Create (global::pMixins.Mvc.Recipes.Repository.MyEntity entity)
					{
						return base.ExecuteMethod ("Create", new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.Parameter> {
							new global::CopaceticSoftware.pMixins.Interceptors.Parameter {
								Name = "entity",
								Type = typeof(global::pMixins.Mvc.Recipes.Repository.MyEntity),
								Value = entity
							}
						}, () => _mixinInstance.Create (entity));
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					internal global::pMixins.Mvc.Recipes.Repository.MyEntity ReadById (global::System.Int32 id)
					{
						return base.ExecuteMethod ("ReadById", new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.Parameter> {
							new global::CopaceticSoftware.pMixins.Interceptors.Parameter {
								Name = "id",
								Type = typeof(global::System.Int32),
								Value = id
							}
						}, () => _mixinInstance.ReadById (id));
					}
				}
			}
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public global::System.Boolean Create (global::pMixins.Mvc.Recipes.Repository.MyEntity entity)
		{
			return ___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.Create (entity);
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public global::pMixins.Mvc.Recipes.Repository.MyEntity ReadById (global::System.Int32 id)
		{
			return ___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__.ReadById (id);
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public static implicit operator global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity> (AnotherTestMyEntityRepository target) {
			return target.___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__._mixinInstance;
		}
		global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity> global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository<global::pMixins.Mvc.Recipes.Repository.MyEntity>>.MixinInstance {
			get {
				return ___mixins.pMixins_Mvc_Recipes_MixinMasks_InMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__._mixinInstance;
			}
		}
	}
}
namespace pMixins.AutoGenerated.pMixins.Mvc.Recipes.MixinMasks.AnotherTestMyEntityRepository.pMixins.Mvc.Recipes.MixinMasks.InMemoryRepository
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.1.13.355")]
	public interface IInMemoryRepository__pMixins_Mvc_Recipes_Repository_MyEntity__Requirements
	{
	}
}