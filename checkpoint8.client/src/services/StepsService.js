import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class StepsService {
  async getStepsForRecipe(id) {
    const res = await api.get(`api/recipes/${id}/steps`)
    AppState.activeSteps = res.data
  }
}

export const stepsService = new StepsService()