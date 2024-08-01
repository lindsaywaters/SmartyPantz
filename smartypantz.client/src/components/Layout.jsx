import { Outlet } from 'react-router-dom';
import NavbarComponent from './NavigationBar'; // Adjust import path as necessary

const Layout = () => {
    return (
        <div>
            <NavbarComponent />
            <main>
                <Outlet /> 
            </main>
        </div>
    );
};

export default Layout;
