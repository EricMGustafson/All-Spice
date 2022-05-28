using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Repositories;

namespace checkpoint8.Services
{
  public class StepsService
  {
    private readonly StepsRepository _repo;

    public StepsService(StepsRepository repo)
    {
      _repo = repo;
    }

    internal List<Step> GetStepsForRecipe(int id)
    {
      return _repo.GetStepsForRecipe(id);
    }

    internal Step Get(int id)
    {
      Step step = _repo.Get(id);
      if (step == null)
      {
        throw new Exception("Invalid Step Id");
      }
      return step;
    }

    internal Step Create(Step stepData)
    {
      return _repo.Create(stepData);
    }

    internal Step Edit(Step stepData)
    {
      Step original = Get(stepData.Id);
      if (original.CreatorId != stepData.CreatorId)
      {
        throw new Exception("This is not your step.");
      }
      original.Body = stepData.Body ?? original.Body;
      original.Position = stepData.Position != 0 ? stepData.Position : original.Position;
      _repo.Edit(original);
      return Get(original.Id);
    }

    internal void Delete(int id, string userId)
    {
      Step step = Get(id);
      if (step.CreatorId != userId)
      {
        throw new Exception("This step does nto belong to you.");
      }
      _repo.Delete(id);
    }
  }
}