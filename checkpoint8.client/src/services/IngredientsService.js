import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService {
  async getIngredientsForRecipe(id) {
    const res = await api.get(`api/recipes/${id}/ingredients`)
    AppState.activeIngredients = res.data
  }
}

export const ingredientsService = new IngredientsService()