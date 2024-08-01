import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import Activity from './components/Activity';
import Badges from './components/Badges';
import SkillsCenter from './components/SkillsCenter';
import SkillSelector from './components/SkillSelector';
import Login from './components/Login';
import ResourcePage from './components/Resources';
import DisplayHomePage from './components/HomePage';
import DisplayUserDashboard from './components/DisplayUserDashboard';
import CreateAccountForm from './components/CreateAccount';
import AuthorizeAccess from './components/AuthRoute';
import './App.css'

function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<DisplayHomePage />} />
        <Route path="/dashboard" element={<AuthorizeAccess element={<DisplayUserDashboard />} />} />
        <Route path="/create-account" element={<CreateAccountForm />} />
        <Route path="/activity/:skillId" element={<AuthorizeAccess element={<Activity />} />} />
        <Route path="/skillsCenter" element={<AuthorizeAccess element={<SkillsCenter />} />} />
        <Route path="/skillSelector" element={<AuthorizeAccess element={<SkillSelector />} />} />
        <Route path="/badges" element={<AuthorizeAccess element={<Badges />} />} />
        <Route path="/login" element={<Login />} />
        <Route path="/resources" element={<ResourcePage />} />
      </Route>
    </Routes>
  );
}

export default App;
