import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService {
  async getIngredientsForRecipe(id) {
    const res = await api.get(`api/recipes/${id}/ingredients`)
    AppState.activeIngredients = res.data
  }
  async addIngredient(formData) {
    const res = await api.post(`api/recipes/${formData.recipeId}/ingredients`, formData)
    AppState.activeIngredients.push(res.data)
  }
  async deleteIngredient(ingredientId, recipeId) {
    await api.delete(`api/recipes/${recipeId}/ingredients/${ingredientId}`)
    AppState.activeIngredients = AppState.activeIngredients.filter(i => i.id != ingredientId)
  }
}

export const ingredientsService = new IngredientsService()