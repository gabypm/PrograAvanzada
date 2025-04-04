using AdvancedProgramming.Architecture.Extensions;
using AdvancedProgramming.Data;
using AdvancedProgramming.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using APT = AdvancedProgramming.Data;

namespace AdvancedProgramming.Helpers
{
    public class TaskConverter
    {
        public static APT.Task ToTask(TaskViewModel viewModel)
        {
            return new APT.Task
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Status = viewModel.Status,
                CreatedAt = viewModel.CreatedAt.ToDateTime(),
                DueDate = viewModel.DueDate.ToDateTime(),
            };
        }

        public static TaskViewModel ToTaskViewModel(APT.Task task)
        {
            return new TaskViewModel
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt.ToDateTimeString(),
                DueDate = task.DueDate.ToDateTimeString()
            };
        }
    }
}