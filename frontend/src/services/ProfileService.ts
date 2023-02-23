const savedProfileKey = 'saved-profile';

function getSavedProfile(): Profile | null {
    var savedProfileJson = localStorage.getItem(savedProfileKey);

    if (savedProfileJson === null) return null;

    return JSON.parse(savedProfileJson);
}

function saveProfile(profile: Profile) {
    var profileJson = JSON.stringify(profile);

    localStorage.setItem(savedProfileKey, profileJson);
}

export default {
    getSavedProfile,
    saveProfile
};