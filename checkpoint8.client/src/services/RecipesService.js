import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class RecipesService {

  async getAllRecipes() {
    const res = await api.get('api/recipes')
    AppState.recipes = res.data
  }
  async createRecipe(formData) {
    const res = await api.post('api/recipes', formData)
    AppState.recipes.push(res.data)
  }
  async deleteRecipe(recipeId) {
    await api.delete(`api/recipes/${recipeId}`)
    AppState.recipes = AppState.recipes.filter(r => r.id != recipeId)
  }
}

export const recipesService = new RecipesService();