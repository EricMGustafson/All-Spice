import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {
  async getAccountFavorites() {
    const res = await api.get('account/favorites')
    AppState.favorites = res.data
    logger.log(AppState.favorites, 'favorites')
  }
  async addFavorite(recipeId, accountId) {
    const res = await api.post('account/favorites', recipeId, accountId)
    AppState.favorites.push(res.data)
  }
}

export const favoritesService = new FavoritesService()