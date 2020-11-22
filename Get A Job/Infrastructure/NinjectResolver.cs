using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Get_A_Job.Controllers;
using Get_A_Job.Interfaces;
using Get_A_Job.Models;
using Get_A_Job.Services;

namespace Get_A_Job.Infrastructure
{
	public class NinjectResolver : IDependencyResolver
	{
		IKernel _kernel;
		public NinjectResolver(IKernel kernel)
		{
			_kernel = kernel;
			AddBindings();

		}

		public void AddBindings()
		{
			_kernel.Bind<ApplicationDbContext>().ToSelf();
			_kernel.Bind<IAdmin>().To<AdminServices>();
			_kernel.Bind<ISendMail>().To<SendMailServices>();
			_kernel.Bind<IJobApplication>().To<JobApplicationServices>();
			_kernel.Bind<IApplicant>().To<ApplicantServices>();
		}

		public object GetService(Type serviceType) => _kernel.TryGet(serviceType);

		public IEnumerable<object> GetServices(Type serviceType) => _kernel.GetAll(serviceType);
	}
}