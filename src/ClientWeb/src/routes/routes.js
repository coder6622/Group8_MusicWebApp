import config from '../config';
import Favorites from '../pages/Favorites/Favorites';
import Feed from '../pages/Feed/Feed';
import Player from '../pages/Player/Player';
import Playlist from '../pages/Playlist/Playlist';
import Trending from '../pages/Trending/Trending';

const publicRoutes = [
  { path: config.routes.feed, component: Feed },
  { path: config.routes.playlist, component: Playlist },
  { path: config.routes.trending, component: Trending },
  { path: config.routes.player, component: Player },
  { path: config.routes.favorites, component: Favorites },
];

const privateRoutes = [];

export { publicRoutes, privateRoutes };
