import Config from "../config/config";

export function GetImage(imageId: string) {
  return Config.BaseURL + "images/" + imageId;
}

export function GetAvatar(imageId: string | null) {
  return imageId ? GetImage(imageId) : Config.DefaultImage;
}
