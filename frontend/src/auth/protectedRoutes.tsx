import { useLocation, Navigate } from "react-router-dom";

import useAuth from "./useAuth";
import CustomBeatLoader from "../components/beatLoader";

const ProtectedRoutes = ({ children }) => {
  const { userLoading, user } = useAuth();

  const location = useLocation();

  if (userLoading) return <CustomBeatLoader />;

  return user ? (
    children
  ) : (
    <Navigate to="/login" state={{ from: location.pathname }} replace />
  );
};

export default ProtectedRoutes;
