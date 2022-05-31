import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class StepsService {
  async getStepsForRecipe(id) {
    const res = await api.get(`api/recipes/${id}/steps`)
    AppState.activeSteps = res.data
  }
  async addStep(formData) {
    const res = await api.post(`api/recipes/${formData.recipeId}/steps`, formData)
    AppState.activeSteps.push(res.data)
  }
  async deleteStep(stepId, recipeId) {
    await api.delete(`api/recipes/${recipeId}/steps/${stepId}`)
    AppState.activeSteps = AppState.activeSteps.filter(s => s.id != stepId)
  }
}

export const stepsService = new StepsService()